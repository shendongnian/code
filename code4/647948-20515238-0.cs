    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using System.IO;
    
    namespace kamera
    {
        public partial class Form1 : Form
        {
    
            //private static String imageUrl = "http://10.10.10.1/now.jpg";
            private static String imageUrl=null;
            private static Thread t ;  
            private static Image webImage;
            private static List<String> kamere;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            private static int intervalOsvezevanja=3000; //3 sekunde osveževanja
            public Form1()
            {
                InitializeComponent();
                ////timer k pokliče funkcijo vsake 3 sekunde
                //AutoResetEvent autoEvent = new AutoResetEvent(false);
                //TimerCallback tcb = updatePicture;
                //System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 0, 200);
    
    
                t = new Thread(updatePicture);
                t.IsBackground = true;
                t.Start();
    
                timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
                timer.Interval = (intervalOsvezevanja) ;             // Timer will tick every 0.05 seconds
                timer.Enabled = true;                       // Enable the timer
                timer.Start();                              // Start the timer
                
                //skrijemo formo za dodajanje kamer
                panelDodajKamero.Hide();
    
                //inicializacija
                kamere = new List<String>();
                tbNaslovKamere.Text =  "cam-kk-";
                preberiDatoteko();
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                pictureBox1.Image = webImage;
            }
    
            ~Form1() {
                //t.Join();
                t.Abort();
                timer.Stop();
                timer.Dispose();
            }
    
            private void updatePicture(object stateInfo)
            {
                while (true)
                {
                    if (imageUrl != null)
                    {
                        try
                        {
                            WebRequest requestPic = WebRequest.Create(imageUrl);
                            WebResponse responsePic = requestPic.GetResponse();
                            webImage = Image.FromStream(responsePic.GetResponseStream());
                            //webImage.Save("C:\\Users\\Public\\kamera\\kamera" + fileName + ".jpg");
                        }
                        catch{}
                    }
                    Thread.Sleep(intervalOsvezevanja);
                }
            }
            
            private void pictureBox1_Click(object sender, EventArgs e)
            {
                if (menuStrip1.Visible)
                {
                    menuStrip1.Hide();
                }
                else
                {
                    menuStrip1.Show();
                }
            }
            
            private void menjajKamero(String camAddr)
            {
                if (camAddr.Contains("http"))
                {
                    imageUrl = camAddr;
                }
                else
                {
                    imageUrl = "http://" + camAddr + "/now.jpg"; //link to http://10.10.10.1now.jpg camera live image.
                }
            }
            
            private void btDodajKamero_Click(object sender, EventArgs e)
            {
                String webAddres;
                if (tbNaslovKamere.Text.Contains("http"))
                {
                    webAddres = tbNaslovKamere.Text;
                }
                else
                {
                    webAddres = "http://" + tbNaslovKamere.Text + "/now.jpg";
                }
                if (RemoteFileExists(webAddres))
                {
                    if (!kamere.Contains(tbNaslovKamere.Text) && !kamere.Contains(webAddres))
                    {
                        kamere.Add(tbNaslovKamere.Text);
                        //kamere.Add(webAddres);
                    }
                    menjajKamero(tbNaslovKamere.Text);
                    //menjajKamero(webAddres);
                    panelDodajKamero.Hide();
                    izpisKamer();
                    tbNaslovKamere.Text = "cam-kk-";
                }
                else
                {
                    MessageBox.Show("Ne najdem Kamere");
                }
            }
            
            private void dodajKameroToolStripMenuItem_Click(object sender, EventArgs e)
            {
                panelDodajKamero.Show();
            }
            
            private void izpisKamer()
            {
                //zanka ki odstrani vse prej dodane kamere
                textBox1.Text = kamereToolStripMenuItem.DropDownItems.Count.ToString();
                
                foreach (String kamera in kamere)
                {
                    kamereToolStripMenuItem.DropDownItems.RemoveByKey(kamera);
                }
                
                System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.CurrentDirectory + "\\kamere.txt");
                foreach (String kamera in kamere)
                {
                    ToolStripDropDownButton btTemp = new ToolStripDropDownButton(kamera, null, kameraOnClick, kamera);
                    file.WriteLine(kamera);
                    
                    //dodamo trenutno kamero, ki je v kamerah.txt
                    kamereToolStripMenuItem.DropDownItems.Add(btTemp);
                }
                file.Dispose();
                file.Close();
            }
    
            private void kameraOnClick(object sender, EventArgs e)
            {
                //tbNaslovKamere.Text+=sender.ToString();
                imageUrl = "http://" + sender.ToString() + "/now.jpg";
            }
    
            private void izhodToolStripMenuItem_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
    
            private void preberiDatoteko()
            {
                String vrstica;
                // Read the file as one string.
                if (File.Exists(System.Environment.CurrentDirectory + "\\kamere.txt"))
                {
                    kamere = new List<String>();
                    StreamReader myFile = new StreamReader(System.Environment.CurrentDirectory + "\\kamere.txt");
                    while ((vrstica = myFile.ReadLine()) != null)
                    {
                        //zapis v list
                        kamere.Add(vrstica);
                        //doda v meni
                        ToolStripDropDownButton btTemp = new ToolStripDropDownButton(vrstica, null, kameraOnClick, vrstica);
                        kamereToolStripMenuItem.DropDownItems.Add(btTemp);
                    }
                    myFile.Close();
                }
            }
            
            private void menuPobrisiKamere()
            {
                foreach (String kamera in kamere)
                {
                    kamereToolStripMenuItem.DropDownItems.RemoveByKey(kamera);
                }
                kamere = new List<String>();
            }
            
            private void odpriToolStripMenuItem_Click(object sender, EventArgs e)
            {
                // Create an instance of the open file dialog box.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                
                // Set filter options and filter index.
                openFileDialog1.Filter = "Text Files (.txt)|*.txt";
                openFileDialog1.FilterIndex = 1;
                
                //openFileDialog1.Multiselect = true;
                // Call the ShowDialog method to show the dialog box.
                DialogResult userClickedOK = openFileDialog1.ShowDialog();
                
                //tbNaslovKamere.Text = userClickedOK.ToString();
                // Process input if the user clicked OK.
                if (userClickedOK.ToString().Equals("OK"))
                {
                    menuPobrisiKamere();
                    String vrstica;
                    
                    // Open the selected file to read.
                    System.IO.Stream fileStream = openFileDialog1.OpenFile();
                    kamere = new List<String>();
                    StreamReader myFile = new StreamReader(fileStream);
                    while ((vrstica = myFile.ReadLine()) != null)
                    {
                        //zapis v list
                        kamere.Add(vrstica);
                        //doda v meni
                        ToolStripDropDownButton btTemp = new ToolStripDropDownButton(vrstica, null, kameraOnClick, vrstica);
                        kamereToolStripMenuItem.DropDownItems.Add(btTemp);
                    }
                    myFile.Dispose();
                    myFile.Close();
                    fileStream.Dispose();
                    fileStream.Close();
                    myFile.Close();
                    fileStream.Close();
                }
            }
            
            private void pobrišiKamereToolStripMenuItem_Click(object sender, EventArgs e)
            {
                menuPobrisiKamere();
            }
            
            private void zbrišiShranjeneKamereToolStripMenuItem_Click(object sender, EventArgs e)
            {
                menuPobrisiKamere();
                System.IO.StreamWriter file = new System.IO.StreamWriter(System.Environment.CurrentDirectory + "\\kamere.txt");
                file.Dispose();
                file.Close();
            }
            
            private void pictureBox1_DoubleClick(object sender, EventArgs e)
            {
                Form1 frm1 = new Form1();
                frm1.Size = new Size(100, frm1.Size.Height);
            }
            
            private bool RemoteFileExists(string url)
            {
                try
                {
                    //Creating the HttpWebRequest
                    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                    //Setting the Request method HEAD, you can also use GET too.
                    request.Method = "HEAD";
                    //Getting the Web Response.
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    //Returns TRUE if the Status code == 200
                    return (response.StatusCode == HttpStatusCode.OK);
                }
                catch
                {
                    //Any exception will returns false.
                    return false;
                }
            }
        }
    }
