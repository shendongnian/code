        /// <summary>
        /// Enabling or Disabling CAPSLOCK button.
        /// Based on value retirevied from settings and also present CAPSLOCK button status.
        /// </summary>
        public void CharacterCasing()
        {
            if (settings.IsCapsLockOn ^ Console.CapsLock)
            {
                const int KEYEVENTF_EXTENDEDKEY = 0x1;
                const int KEYEVENTF_KEYUP = 0x2;
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
        }
