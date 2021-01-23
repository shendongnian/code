    public class MvxPhoneCallTask : MvxTouchTask, IMvxPhoneCallTask
    {
        #region IMvxPhoneCallTask Members
        public void MakePhoneCall(string name, string number)
        {
			var url = new NSUrl("tel:" + number);
            DoUrlOpen(url);
        }
        #endregion
    }
