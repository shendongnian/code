    //Inside void WriteFileCommandExecuted()
               
     System.IO.StreamReader sr = new System.IO.StreamReader("File Path");
                    textBox1.Text =  sr.ReadToEnd();
            
            //Or if you need more control
            System.IO.FileStream fs = new System.IO.FileStream(FirmwarePath, System.IO.FileMode.CreateNew);
            System.IO.StreamReader sr = new System.IO.StreamReader(fs);
            string textdata = sr.ReadToEnd();
            int fileSize = (int)new System.IO.FileInfo(FirmwarePath).Length;
            Byte f_buffer = new Byte();
            f_buffer = Convert.ToByte(textdata);
            int cnt = 0;
        
        //The FirmwarePath is the path returned to you by your file dialog box.
        //If you want to write the class you will need to instantiate is System.IO.StreamWriter then //invoke the "write" method
