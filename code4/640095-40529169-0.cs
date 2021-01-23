    public class MessageBox
    {
        ModalPopupExtender _modalPop;
        Page _page;
        object _sender;
        Panel _pnl;
        public enum Buttons
        {
            AbortRetryIgnore,
            OK,
            OKCancel,
            RetryCancel,
            YesNo,
            YesNoCancel
        }
        public enum DefaultButton
        {
            Button1,
            Button2,
            Button3
        }
        public enum MessageBoxIcon
        {
            Asterisk,
            Exclamation,
            Hand,
            Information,
            None,
            Question,
            Warning
        }
        public MessageBox(Page page, object sender, Panel pnl)
        {
            _page = page;
            _sender = sender;
            _pnl = pnl;
            _modalPop = new ModalPopupExtender();
            _modalPop.ID = "popUp";
            _modalPop.PopupControlID = "ModalPanel";
        }
       
        public void Show(String strTitle, string strMessage, Buttons buttons, DefaultButton defaultbutton, MessageBoxIcon msbi)
        {
            MasterPage mPage = _page.Master;
            Label lblTitle = null;
            Label lblError = null;
            Button btn1 = null;
            Button btn2 = null;
            Button btn3 = null;
            Image imgIcon = null;
            
            lblTitle = ((Default)_page.Master).messageBoxTitle;
            lblError = ((Default)_page.Master).messageBoxMsg;
            btn1 = ((Default)_page.Master).button1;
            btn2 = ((Default)_page.Master).button2;
            btn3 = ((Default)_page.Master).button3;
            imgIcon = ((Default)_page.Master).messageBoxIcon;
            lblTitle.Text = strTitle;
            lblError.Text = strMessage;
            btn1.CssClass = "btn btn-default";
            btn2.CssClass = "btn btn-default";
            btn3.CssClass = "btn btn-default";
            switch (msbi)
            {
                case MessageBoxIcon.Asterisk:
                    //imgIcon.ImageUrl = "~/img/asterisk.jpg";
                    break;
                case MessageBoxIcon.Exclamation:
                    //imgIcon.ImageUrl = "~/img/exclamation.jpg";
                    break;
                case MessageBoxIcon.Hand:
                    break;
                case MessageBoxIcon.Information:
                    break;
                case MessageBoxIcon.None:
                    break;
                case MessageBoxIcon.Question:
                    break;
                case MessageBoxIcon.Warning:
                    break;
            }
            switch (buttons)
            {
                case Buttons.AbortRetryIgnore:
                    btn1.Text = "Abort";
                    btn2.Text = "Retry";
                    btn3.Text = "Ignore";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = true;
                    
                    break;
                case Buttons.OK:
                    btn1.Text = "OK";
                    btn1.Visible = true;
                    btn2.Visible = false;
                    btn3.Visible = false;
                    break;
                case Buttons.OKCancel:
                    btn1.Text = "OK";
                    btn2.Text = "Cancel";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = false;
                    break;
                case Buttons.RetryCancel:
                    btn1.Text = "Retry";
                    btn2.Text = "Cancel";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = false;
                    break;
                case Buttons.YesNo:
                    btn1.Text = "No";
                    btn2.Text = "Yes";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = false;
                    break;
                case Buttons.YesNoCancel:
                    btn1.Text = "Yes";
                    btn2.Text = "No";
                    btn3.Text = "Cancel";
                    btn1.Visible = true;
                    btn2.Visible = true;
                    btn3.Visible = true;
                    break;
            }
            if (defaultbutton == DefaultButton.Button1)
            {
                btn1.CssClass = "btn btn-primary";
                btn2.CssClass = "btn btn-default";
                btn3.CssClass = "btn btn-default";
            }
            else if (defaultbutton == DefaultButton.Button2)
            {
                btn1.CssClass = "btn btn-default";
                btn2.CssClass = "btn btn-primary";
                btn3.CssClass = "btn btn-default";
            }
            else if (defaultbutton == DefaultButton.Button3)
            {
                btn1.CssClass = "btn btn-default";
                btn2.CssClass = "btn btn-default";
                btn3.CssClass = "btn btn-primary";
            }
            FirePopUp();
        }
        private void FirePopUp()
        {
            _modalPop.TargetControlID = ((Button)_sender).ID;
            _modalPop.DropShadow = true;
            _modalPop.OkControlID = //btn 1 / 2 / 3;
            _modalPop.CancelControlID = //btn 1 / 2 / 3;
            _modalPop.BackgroundCssClass = "modalBackground";
            _pnl.Controls.Add(_modalPop);
            _modalPop.Show();
        }
