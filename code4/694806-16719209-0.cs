     // read file
                List<string> query = (from lines in File.ReadLines(this.Location.FullName, System.Text.Encoding.UTF8)
                                      select lines).ToList<string>();
    
    for(i=0; i<query.count();i++)
    {
    if(query[i].contains("TextYouWant")){
    i=i+3;}
    else continue;
    }
