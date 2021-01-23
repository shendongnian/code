    public class MainViewModel : ViewModelBase
    {
        #region Declarations
        private ColorSettingsSequencesSequence currentSequence;
        private ObservableCollection<ColorSettingsSequencesSequence> colorSettingsSequences;
        
        #endregion
        #region Properties
        /// <summary>
        /// Gets or sets the current sequence.
        /// </summary>
        /// <value>
        /// The current sequence.
        /// </value>
        public ColorSettingsSequencesSequence CurrentSequence
        {
            get
            {
                return this.currentSequence;
            }
            set
            {
                this.currentSequence = value;
                OnPropertyChanged("CurrentSequence");
            }
        }
        /// <summary>
        /// Gets or sets the color settings sequences.
        /// </summary>
        /// <value>
        /// The color settings sequences.
        /// </value>
        public ObservableCollection<ColorSettingsSequencesSequence> ColorSettingsSequences
        {
            get
            {
                return this.colorSettingsSequences;
            }
            set
            {
                this.colorSettingsSequences = value;
                OnPropertyChanged("ColorSettingsSequences");
            }
        }
        #endregion
        #region Commands
        
        #endregion
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        public MainViewModel()
        {
            this.ColorSettingsSequences = new ObservableCollection<ColorSettingsSequencesSequence>();
            ColorSettingsSequencesSequence sequence1 = new ColorSettingsSequencesSequence();
            sequence1.StartColor = "Blue";
            sequence1.StartTemperature = "10";
            sequence1.EndTemperature = "50";
            ColorSettingsSequences.Add(sequence1);
            ColorSettingsSequencesSequence sequence2 = new ColorSettingsSequencesSequence();
            sequence2.StartColor = "Red";
            sequence2.StartTemperature = "20";
            sequence2.EndTemperature = "60";
            ColorSettingsSequences.Add(sequence2);
            ColorSettingsSequencesSequence sequence3 = new ColorSettingsSequencesSequence();
            sequence3.StartColor = "Yellow";
            sequence3.StartTemperature = "30";
            sequence3.EndTemperature = "70";
            ColorSettingsSequences.Add(sequence3);
            this.CurrentSequence = sequence1;
        }
        #endregion
        #region Private Methods
        #endregion
    }
