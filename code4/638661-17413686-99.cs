    public class ParcelView : Activity
    {
        protected ViewPager _viewPager;
        private List<Android.App.Fragment> _fragments;
    		
        public interface IFragmentToViewPagerEvent
        {
            void ParcelRecordFieldClickEvent(Fragment child, View focused);
        }
    	
        void IFragmentToViewPagerEvent.ParcelRecordFieldClickEvent(Fragment child, View focused)
        {
            _viewPager.RequestChildFocus2(null, focused);
        }	
    }
