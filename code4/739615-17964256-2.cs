       public void usbforProcessExited(object sender, EventArgs f)
        {
            var ev = SetStatusEvent; //[1]
            if(ev!=null) //[2]
                ev(100, "DONE", Color.Green);
        }
