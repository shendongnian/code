     private void button1_Click(object sender, EventArgs e)
            {
                System.IO.StreamReader filetoprint;
                  filetoprint = new System.IO.StreamReader(@"D:\\m.txt");
                  printDocument1.Print();
                  filetoprint.Close();
            }
