    string id = "LSHOE-UCT";    
    string[] arr = id.Split('-');
    string gender = id.Substring(0,1); // give you L
    string product = arr[0].Substring(1); // give you shoe
    string category = arr[1]; // give you UCT;
