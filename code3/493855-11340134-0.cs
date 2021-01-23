    public void Method1()
        {
            string variable1 = "$variable1";
            string variable2 = "$variable2";
            string file = System.IO.File.ReadAllText(@"C:\temp\textfile.txt", System.Text.Encoding.UTF8);
            try
            {
                if (File.Exists(@"C:\temp\textfile.txt"))
                {
                    // NOP: Nothing to DO
                }
                if (file.Contains(variable1infile))
                {
                    file = fileContents.Replace(variable1, variable1infile);
                    System.IO.File.WriteAllText(@"C:\temp\textfile.txt", file);
                    var reload = File.ReadAllText(@"C:\temp\textfile.txt");
                    TextBox1.Text = reload;
                }
                if (file.Contains(variable2infile))
                {
                    file = fileContents.Replace(variable2, variable2infile);
                    System.IO.File.WriteAllText(@"C:\temp\textfile.txt", file);
                    var reload = File.ReadAllText(@"C:\temp\textfile.txt");
                    TextBox1.Text = reload;
                }
				var gettextback = File.ReadAllText(@"C:\temp\another_textfile.txt");
                File.WriteAllText(@"C:\temp\textfile.txt", gettextback);
            }
            catch
            {
                TextBox1.Visible = true;
                TextBox1.Text = "The file is not avaiable. Please contact your administrator!";
            }
        }
