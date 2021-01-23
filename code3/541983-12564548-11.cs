    public class MvxPhoneCallTask : MvxAndroidTask, IMvxPhoneCallTask
    {
        #region IMvxPhoneCallTask Members
        public void MakePhoneCall(string name, string number)
        {
            var phoneNumber = PhoneNumberUtils.FormatNumber(number);
            var newIntent = new Intent(Intent.ActionDial, Uri.Parse("tel:" + phoneNumber));
            StartActivity(newIntent);
        }
        #endregion
    }
