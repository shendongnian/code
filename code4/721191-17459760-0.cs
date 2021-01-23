       private void editText()
        {
            System.IO.StreamReader read = new System.IO.StreamReader(filePath);
            
            //write to new file because it's not possible to replace text in existing file directly
            System.IO.TextWriter writer = new System.IO.TextWriter(filePath+"_"); 
            while ((line = read.ReadLine()) != null)
            {
                writer.WriteLine(line); //write unmodified line to new file
                   
                if (startLine == line)
                {
                    while ((line = read.ReadLine()) != null)
                    {
                        if (line == endLine)
                        {
                            writer.WriteLine(line); //write unmodified line to new file
                            break;  //exit cycle
                        }
                        else
                        {
                            line = line.Replace(oldFont, newFontS); //replace content in line
                            writer.WriteLine(line); //write modified line to new file
                        }                       
                    }
                }
            }
            read.Close();
            writer.Close(); 
            System.IO.File.Delete(filePath); //delete old file
            System.IO.File.Move(filePath+"_",filePath); //rename new file to original filename            
             
            MessageBox.Show("Done!");
        }
