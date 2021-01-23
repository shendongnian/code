        /// <summary>
        /// Event for Slot Command Button
        /// </summary>
        private ICommand mSlotCommand;
        public ICommand SlotCommand
        {
            get
            {
                if (mSlotCommand == null)
                    mSlotCommand = new DelegateCommand(new Action(mSlotCommandExecuted), new Func<bool>(mSlotCommandCanExecute));
                return mSlotCommand;
            }
            set
            {
                mSlotCommand = value;
            }
        }
        public bool mSlotCommandCanExecute()
        {
            return true;
        }
        public void mSlotCommandExecuted()
        {
            
        }
