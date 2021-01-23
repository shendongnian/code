    string space200 = "                                                                                                                                                                                                                                                                                                                                                                                    ";
          if (File.Exists(DLFile))
          {
            using (StreamWriter sw = new StreamWriter(DLFile))
            {
              StringBuilder stringBuilder = new StringBuilder();
              stringBuilder.Append("001").Append(partNumber).Append(space200.Substring(stringBuilder.ToString().Length, space200.Length - stringBuilder.ToString().Length)).AppendLine();
    
              String innerString = stringBuilder.ToString();
              sw.WriteLine(innerString);
              sw.Close();
            }
          }
