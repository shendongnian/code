     string Source = textBox13.Text;
     for (i = Source.Length - 1; i >=0; i--)
     {
          if (! Char.IsNumber(Source[i])
             break;
     }
     string leftString = Source.Left(i+1);
     string rightString = Source.Right(i+1,Source.Length-i-1);
