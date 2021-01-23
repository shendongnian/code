    string[] lines = File.ReadAllLines(path);
    if(lines.Lenght >= 200){
        for(int i = 0; i < 200; i++){
              string[] str = lines[i].Split(',');
              //do something here
        }
    }
