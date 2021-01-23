        Random _zufall;
        ButtonAktivieren _aktivierenCallback;
        public void Test (Random zufall, ButtonAktivieren aktivierenCallback)
        {
            _zufall = zufall;
            _aktivierenCallback = aktivierenCallback;
        }
        public void Aktivieren()
        {
            passiv = true;
    
            anzahlGezeigt++;
            if (anzahlGezeigt % 2 == 0)
            {
                _aktivierenCallback(button, passiv);
            }
            if (anzahlGezeigt %2 > 0)
            {
            button = _zufall.Next(1, 6);
            _aktivierenCallback(button, passiv);    
            }
        }
        
