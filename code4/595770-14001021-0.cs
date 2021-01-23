     private void btnlogin_Click(object sender, EventArgs e)
        {
            string s1 = getIP();
            string dir = "D://"+s1+"-"+DateTime.Now+"Login.hhh";
            if (!File.Exists(dir))
            {
                File.Create(dir);
            }
    
            string filePath = dir;
            string s = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            
            using (StreamWriter swrObj = new StreamWriter(filePath, true))
            {
                swrObj.Write(s1 + "|" + s + "|" + Txtusername.Text + "|" + "user logged in on :|" + DateTime.Now.ToShortDateString() + " at " + DateTime.Now.ToShortTimeString());
                swrObj.Write("\t\t");
                swrObj.Write("\t\t");
                swrObj.WriteLine();
                MessageBox.Show("Login success");
            }
        }
