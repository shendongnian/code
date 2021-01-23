            string splitMe = "test1,test2,";
            string[] splitted1 = splitMe.Split(',');
            string[] splitted2 = splitMe.Split(new char[]{','},StringSplitOptions.RemoveEmptyEntries);
            //Will be length 3 due to extra comma
            MessageBox.Show(splitted1.Length.ToString());
            //Will be length 2, Removed the empty entry since there was nothing after the comma
            MessageBox.Show(splitted2.Length.ToString());
