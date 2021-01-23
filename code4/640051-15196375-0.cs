    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            string myText = "MusLum";
            string encrypted = "";
            string decrypted = "";
            char shift = 'a';
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Encrypt_Click(object sender, EventArgs e)
            {
                string encrypt = myText;
          
                bool tbNull = myText == "";
    
                if (tbNull)
                    MessageBox.Show("There is nothing to encrypt.");
    
                else
                {
                    char[] array = encrypt.ToCharArray();
    
                    for (int i = 0; i < array.Length; i++)
                    {
                        int num = (int)array[i];
                        if (num >= 'a' && num <= 'z')
                        {
                          
                            num += (Convert.ToInt32(shift.ToString().ToLower()[0]) - Convert.ToInt32('a')+1);
                            
                            if (num > 'z')
                            {
                                num = num - 26;
                            }
                        }
                        else if (num >= 'A' && num <= 'Z')
                        {
                            num += (Convert.ToInt32(shift.ToString().ToUpper()[0]) - Convert.ToInt32('A')+1);
                           
                            if (num > 'Z')
                            {
                                num = num - 26;
                            }
                        }
                        array[i] = (char)num;
                    }
                
                    encrypted = new string(array);
                }
    
            
            }
    
            private void Decrypt_Click(object sender, EventArgs e)
            {
                string decrypt = encrypted;
    
    
                bool tbNull = encrypted == "";
    
                if (tbNull)
                    MessageBox.Show("There is nothing to decrypt.");
    
                else
                {
                    char[] array = encrypted.ToCharArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        int num = (int)array[i];
                        if (num >= 'a' && num <= 'z')
                        {
                            num -= (Convert.ToInt32(shift.ToString().ToLower()[0]) - Convert.ToInt32('a')+1);
                            
                            if (num > 'z')
                                num = num - 26;
    
                            if (num < 'a')
                                num = num + 26;
                        }
                        else if (num >= 'A' && num <= 'Z')
                        {
                            num -= (Convert.ToInt32(shift.ToString().ToUpper()[0]) - Convert.ToInt32('A')+1);
                           
                            if (num > 'Z')
                                num = num - 26;
    
                            if (num < 'A')
                                num = num + 26;
                        }
                        array[i] = (char)num;
                    }
                
                    decrypted = new string(array);
                }
            }
        }
    }
