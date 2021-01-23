    String data = "Vks - Vks * Son";
    String[] pieces = (from piece in data.Split(new char[]{'-', '*'}, StringSplitOptions.RemoveEmptyEntries)
    								select piece.Trim()).ToArray();
    			
    Console.WriteLine(pieces[0]);
    Console.WriteLine(pieces[1]);
    Console.WriteLine(pieces[2]);
