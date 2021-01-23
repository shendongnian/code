    string line, generated;
    using(System.IO.StreamReader file = new System.IO.StreamReader("source.txt", System.Text.Encoding.UTF8)){
       using(System.IO.StreamWriter w = new System.IO.StreamWriter("data.sql", false, System.Text.Encoding.UTF8)){
         while ((line = file.ReadLine()) != null)
           {
            String[] ar = line.Split('|');
            generated = "INSERT INTO `translation` VALUES('" + ar[0] + "'," + ar[1] + ");";
            w.WriteLine(generated);
           }
        }
    }
