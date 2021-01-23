    public void removeXMLdeclaration()
        {
            try
            {
                //Grab file
                StreamReader sr = new StreamReader(xmlPath);
                
                //Read first line and do nothing (i.e. eliminate XML declaration)
                sr.ReadLine();
                string body = null;
                string line = sr.ReadLine();
                while(line != null) // read file into body string
                {
                    body += line + "\n";
                    line = sr.ReadLine();
                }
                sr.Close(); //close file
                
                //Write all of the "body" to the same text file
                System.IO.File.WriteAllText(xmlPath, body);
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
        }
