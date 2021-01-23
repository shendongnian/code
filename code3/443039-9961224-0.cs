    public enum StatusOption 
    { 
        Online, 
        Offline, 
        Warning 
    } 
     
    public class Actions 
    { 
        private static SortedDictionary<Tools.StatusOption,SolidColorBrush> StatusColors = new SortedDictionary<Tools.StatusOption,SolidColorBrush>(); 
     
        static Actions() 
        { 
            StatusColors.Add(Tools.StatusOption.Online, new SolidColorBrush(Colors.Green)); 
            StatusColors.Add(Tools.StatusOption.Offline, new SolidColorBrush(Colors.Red)); 
            StatusColors.Add(Tools.StatusOption.Warning, new SolidColorBrush(Colors.Orange)); 
        } 
     
        public static void SetStatus(Tools.StatusOption _statusOption, TextBlock _txtBlock) 
        { 
            _txtBlock.Text = _statusOption.ToString(); 
            _txtBlock.Foreground = StatusColors[_statusOption]; 
        } 
    } 
