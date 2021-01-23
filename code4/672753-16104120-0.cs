    string line;
    float sum=0;
    float avg=0;
    
    using(StreamReader sr = new StreamReader("C:\\grades.txt"))
    using(StreamWriter sw = new StreamWriter("C:\\ava.txt"))
    {
        while ((line = sr.ReadLine()) != null)
        {
            if ((line[0] >= 65 && line[0] <= 90) || (line[0] >= 97 && line[0] <= 122))
            {
                avg = sum / 3;
                if (avg != 0)
                    sw.WriteLine(avg.ToString());
                sum = 0;
                avg = 0;
                sw.WriteLine(line);
            }
            else
            {
                sw.WriteLine(line);
                sum += float.Parse(line);
            }
        }
    }
