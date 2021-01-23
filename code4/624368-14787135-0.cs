            String mask = "*.mdl";
            String source = @"c:\source\";
            String destination = @"C:\Viewer\Models\";
            String[] files = Directory.GetFiles(source, mask, SearchOption.AllDirectories);
           
           foreach (String file in files)
           {
               if (File.Exists(file) && !File.Exists(destination + new FileInfo(file).Name))
               {
                   File.Move(file, destination + new FileInfo(file).Name);
               }
               else
               {
                   FileInfo f = new FileInfo(file);
                   long s = f.Length;
                   FileInfo f2 = new FileInfo(destination + new FileInfo(file).Name);
                   long s2 = f2.Length;
                   if (s >= s2)
                   {
                       File.Delete(destination + new FileInfo(file).Name);
                       File.Move(file, destination + new FileInfo(file).Name);
                   }
               }
	    //mycompiledapp.exe is placed in Viewer folder for this to work
            myprocess = Process.Start(@"viewer.exe"); 
            Thread.Sleep(3000);
            if (myprocess.HasExited) //Process crashes, exiting automatically
            {
		//Deletes the file that makes the viewer.exe crash
                File.Delete(destination + new FileInfo(file).Name); 
            }
            else
            {
                myprocess.Kill();
            }
           }
