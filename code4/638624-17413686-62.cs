    public class ParcelView : Activity, RecordView.IFragmentToViewPagerEvent
    {
        protected ViewPager _viewPager;
        private List<Android.App.Fragment> _fragments;
    		
        public interface IFragmentToViewPagerEvent
        {
    	...
            void ParcelRecordFieldClickEvent(Fragment child, View focused);
        }
    	
        private View _focused;
        public void IFragmentToViewPagerEvent.ParcelRecordFieldClickEvent(Fragment child, View focused)
        {
            if( _focused != null )
            {
                _focused.ClearFocus();
            }
            _focused = focused;
        }	
    }
