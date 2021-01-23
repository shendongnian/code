    public class WaveButton
    {
        public int Number { get; set; }
        public string WaveFilePath { get; set; }
    }
    .....
    button.Tag = new WaveButton() { Number = n, WaveFilePath = path }
