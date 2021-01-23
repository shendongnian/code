    var allExist = true;
    for (var i = 0; allExist && i != 4; i++) {
        vert[0] = w0[i];
        vert[1] = w1[i];
        vert[2] = w2[i];
        vert[3] = w3[i];
        allExist = Words.Contains(new string(vert));
    }
    if (allExist) {
        found = true;
        Console.WriteLine(w0);
        Console.WriteLine(w1);
        Console.WriteLine(w2);
        Console.WriteLine(w3);
        Console.WriteLine();
    }
