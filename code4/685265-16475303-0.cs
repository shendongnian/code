    string line;
    System.IO.StreamReader file = new System.IO.StreamReader("test.txt");
    //get the date at line 12. The date starts from 9th string and has a length of 11.
    string lineDate = GetLine(@"test.txt", 12);
    string getDate=lineDate.Substring(9,11);
    //get the start time at line 11. The timee starts from 9th string and has a length of 8.
    string lineTime = GetLine(@"test.txt", 11);
    string getTime=lineTime.Substring(9,8);
    //merge date and time
    DateTime TestTime = DateTime.Parse(getDate + " " + getTime); 
    while ((line = file.ReadLine()) != null)
    {
          //Reading the line which contains DISKXFER. Eg:"DISKXFER,T0001,0.5,0.0"
          if (line.Contains("DISKXFER"))
          {
              //split the line and insert to an array, Eg: split[0]=DISKXFER
                string dataLine = line.ToString();
                string[] split = dataLine.Split(',');
                int result = split.Length;
                int n = dataGridView1.Rows.Add();
                //split[] has four elements. Add those elements to four columns in the same row and continue with other lines
                
                //add testtimes to the first column
                dataGridView1.Rows[n].Cells[0].Value = TestTime;
                for (int i = 0; i < result; i++)
                {
                    //add split array to other columns in the same row of testtime. Eg: split[0] to column2, split[1] to column3, split[2] to column4, split[3] to column5
                    dataGridView1.Rows[n].Cells[i + 1].Value = split[i];           
                }
                                  
                TestTime = TestTime.AddMinutes(30);
            }
        }
    file.Close(); 
