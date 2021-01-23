    //Inside void WriteFileCommandExecuted()
               
     System.IO.StreamReader sr = new System.IO.StreamReader("File Path");
                    textBox1.Text =  sr.ReadToEnd();
            
            //Or if you need more control
                    System.IO.FileStream fs = new System.IO.FileStream("File path", System.IO.FileMode.CreateNew)
            
                        System.IO.StreamReader sr = new System.IO.StreamReader(fs);
                        textBox1.Text =  sr.ReadToEnd();
        
        //The file path is the path returned to you by your file dialog box.
        //If you want to write the class you will need to instantiate is System.IO.StreamWriter then //invoke the "write" method
