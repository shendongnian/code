        private void buttonClick()
        {
            DoSomething(condition ? true : false);
        }
        private void DoSomething(bool increment)
        {
            // do stuff
            if (increment)
                ++index;
            else
                --index;
        }
