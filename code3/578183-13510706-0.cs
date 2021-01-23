    Dictionary<string, List<string>> wording = new Dictionary<string, List<string>>();
    public void splitit()
    {          
     utterance[0] = "Fish attacked Nemo's parents";
     utterance[1] = "Only one fish egg left after fish attacked Nemo's parents and that was Nemo.";
     utterance[2] = "Nemo grow up and went to school.";
     utterance[3] = "Nemo got bored during the lecture and went to ocean with his friends.";
        for (int x=0; x < 4; x++)
        {
            string[] words = utterance[x].Split(' ');
            List<string> Tokens = new List<string>();
            foreach (string word in words)
            {
                Tokens.Add(word);
            }
            //string parsed = Tokens[1];
            //foreach(string tok in Tokens)
            //{
            //   List<string> listing = new List<string>();
            //    listing.Add (tok);
            //    wording.Add("utterance"+x, listing);
            //    //listBox1.Items.Add("utterance"+x+" : "+tok);
            //}
            for (int w = 0; w < 4; w++)
            { 
            wording.Add(utterance[w],Tokens);
            }
        }
    }
  }
