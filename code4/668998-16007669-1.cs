    public class LearningStoryItem:DependencyObject
    private static DependencyProperty voteProperty;
        static LearningStoryItem()
        {
            var votePropertyMetadata = new FrameworkPropertyMetadata(Convert.ToDouble(0),
                                                                          FrameworkPropertyMetadataOptions.AffectsRender);
            voteProperty = DependencyProperty.Register("Votes",
                                                           typeof(double),
                                                           typeof(LearningStoryItem),
                                                           votePropertyMetadata);
        }
        public double Votes {
            get { return (double) GetValue(voteProperty); } 
            set {SetValue(voteProperty,value); }  
        }
     
