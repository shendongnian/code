        System.IO.StreamWriter sfile =   new System.IO.StreamWriter(path+file);
        for (int x = 0; x != chans; x++){
           for (int xx = 0; xx != maxsize; xx++){
               sql += data[x, xx] + "," + xx.ToString() + "," + tes + "," + x.ToString()+"\n";
           }
           sfile.Write(sql);
           sql = "";
         }
