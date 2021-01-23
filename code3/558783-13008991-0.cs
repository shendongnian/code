public class IDGenerator
    {
        private int _firstLetter = 0;
        private int _secondLetter = 0;
        private int _firstDigitCounter = 90;
        private string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string NewID()
        {
            return twoLetters();
        }
        private string twoLetters()
        {
            _firstDigitCounter += 1;
            if (_firstDigitCounter == 99)
            {
                _firstDigitCounter = 0;
                _secondLetter += 1;
            }
            if (_secondLetter > _chars.Length)
            {
                _secondLetter = 0;
                _firstLetter += 1;
            }
            return _chars.Substring(_firstLetter, 1) + _chars.Substring(_secondLetter, 1) + " " + _firstDigitCounter.ToString("00") + " " + DateTime.Now.Year.ToString().Insert(3, " ") + DateTime.Now.Date.ToString("MM dd");
        }
    }
