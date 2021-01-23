     void f_ValueChanged(object sender, EventArgs e)
        {
            Boolean isThisProgrammatic = isProgrammaticEvent;
            isProgrammaticEvent = false;
            if(isThisProgrammatic)
                return;
            //Do whatever you need when the value changes here
        }
