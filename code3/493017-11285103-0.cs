    string a = "this is a";
    string b = a;
    string c = "this is " + x; //x has the value of 'a'
    string d = "this is a";
    object oa = a;
    object ob = b;
    object oc = c;
    object od = d;
    
    console.WriteLine(a == b); //will print true
    console.WriteLine(a == c); //will print true
    console.WriteLine(c == b); //will print true
    
    console.WriteLine(oa == ob); //will print true
    console.WriteLine(oa == oc); //will print false
    console.WriteLine(oa == od); //will print true
