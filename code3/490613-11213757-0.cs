    string RemoveValues(string sentence, string[] values){
       
       foreach(string s in values){
          while(sentence.IndexOf(s) != -1 && sentence.IndexOf(s) != 0){
             sentence = sentence.Remove(sentence.IndexOf(s), s.Lenght);
          }
       }
       
       return sentence;
    }
