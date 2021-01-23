    using System.IO;
    //------------
    
    string line;
    string s1;
    string s2;
    string s3;
    string s4;
    string s5;
    
    using (StreamReader reader = new StreamReader("file.txt"))
    {
       line = reader.ReadLine();  // 31201011281853000100000000710003
       s1 = line.substring(0,2);  // 31
       s2 = line.substring(3,12); // 201011281853
       s3 = line.substring(13,4); // 0001
       s4 = line.substring(14,10);// 0000000071 
       s5 = line.substring(15,4); // 0003
       
       // Pass s1-s5 to your insert/update statements in DAL.
    }
    
    
