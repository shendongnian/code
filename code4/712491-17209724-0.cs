    using System;
    using System.Windows.Forms;
    using System.Drawing;
    namespace MessageBoxes{
    public sealed class MyErrorBox{
  
    private MyErrorBox(){}
    private static Form frm;
    private static string detailsStore;
    private static TextBox txt;
    public static DialogResult Show(string caption, string text, string details, Icon icon){
        frm = new Form(); frm.Size = new Size(510, 195);
        frm.Text = caption; frm.ShowInTaskbar = false; frm.ControlBox = false;
        frm.FormBorderStyle = FormBorderStyle.FixedDialog;
        PictureBox icon1 = new PictureBox(); icon1.Location = new Point(8,16);
        icon1.Size = new Size(icon.Width, icon.Height);
        icon1.Image = icon.ToBitmap();
        frm.Controls.Add(icon1);
        Label lbl = new Label(); lbl.Text = text; lbl.Location = new Point(88,8);
        lbl.Size = new Size(400,88); frm.Controls.Add(lbl);
        LinkLabel btn1 = new LinkLabel(); btn1.Text = "View Details";
        btn1.Size = new Size(72,23); btn1.Location = new Point(416,96);
        btn1.Click += new EventHandler(btn1_Click); frm.Controls.Add(btn1);
        //Ofcourse you can add more buttons than just the ok with more DialogResults
        Button btn2 = new Button(); btn2.Text = "&Ok";
        btn2.Size = new Size(72,23); btn2.Location = new Point(224,130);
        btn2.Anchor = AnchorStyles.Bottom; frm.Controls.Add(btn2);
        frm.AcceptButton = btn2; btn2.Click += new EventHandler(btn2_Click);
        btn2.DialogResult = DialogResult.OK; detailsStore = details;
        return frm.ShowDialog();
     }
    private static void btn1_Click(object sender, EventArgs e) {
        frm.Size = new Size(510,320);
        txt = new TextBox(); txt.Multiline = true;
        txt.ScrollBars = ScrollBars.Both; txt.Text = detailsStore;
        txt.Size = new Size(488,128); txt.Location = new Point(8,120);
        txt.ReadOnly = true; frm.Controls.Add(txt);
        LinkLabel lnk = (LinkLabel)(sender); lnk.Text = "Hide Details";
        lnk.Click -= new EventHandler(btn1_Click);
        lnk.Click += new EventHandler(btn1_ReClick);
    }
    private static void btn2_Click(object sender, EventArgs e) {
        frm.Close();
    }
    private static void btn1_ReClick(object sender, EventArgs e) {
        frm.Controls.Remove(txt); frm.Size = new Size(510, 195);
        LinkLabel lnk = (LinkLabel)(sender); lnk.Text = "View Details";
        lnk.Click -= new EventHandler(btn1_ReClick);
        lnk.Click += new EventHandler(btn1_Click);
       }
      }
     }
