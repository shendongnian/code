//If there was a way to extract the parts number from each line I would do this
//but I don't know what the format is so I can't provide the code
//cache is a Dictionary<string,List<string>>
if(!cache.ContainsKey(partsNumber.Text))
{
//then search through the file
cache.Add(partsNumber.Text,new List<string>());
using (System.IO.StreamReader file = new System.IO.StreamReader(@"T:\\PARTS\\DATABASE\\PARTS.txt"))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if ((backgroundWorker1.CancellationPending == true))
                    {
                        e.Cancel = true;
                    }
                    else if (line.Contains(partNumbersText.Text))
                    {
                        cache[partNumbersText.Text].Add(line);
                        Action action = () => matchesText.Text += (line + Environment.NewLine).ToString();
                        matchesText.Invoke(action); // Or use BeginInvoke
                    }
                }
        }
}
else //this is where you will save time
{
   foreach(var line in cache[partNumbersText.Text])
   {
       cache[partNumbersText.Text].Add(line);
       Action action = () => matchesText.Text += (line + Environment.NewLine).ToString();
       matchesText.Invoke(action); // Or use BeginInvoke
   }
}
