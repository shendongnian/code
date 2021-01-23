             public partial class MainWindow : Window
             {  
                   bool isSeekingMedia = false;
                   DispatcherTimer seeker;   // the timer to update the Slider
                   public MainWindow()
                   {
                        InitializeComponent();
                        player = new MediaPLayer();
                        IsPlaying(false);
                        seeker = new DispatcherTimer();
                        seeker.Interval = TimeSpan.FromMilliseconds(200);
                        seeker.Tick += Seeker_Tick;
            }
        ///Seeker_Tick will update the Slider position while the video is playing
                    private void Seeker_Tick(object sender, EventArgs e)
                    {
                        try
                        {
                            MediatimeCounter.Content = String.Format("{0:hh}:{0:mm}:{0:ss}/{1:hh}:{1:mm}:{1:ss}", videoPlayer.Position, videoPlayer.NaturalDuration.TimeSpan);
                            if (!isSeekingMedia)
                            {
                                videoSlider.Value = videoPlayer.Position.TotalSeconds;
                            }
                        }
                        catch (Exception ex) { }
                    }
    
        
    //This code is going to set Seeking to true to avoid playing the video if the user is changing the slider position... it kinda causes a performance issue.. so it's better to update the video position once the slider dragging event is completed.
    private void videoSlider_DragStarted(object sender, RoutedEventArgs e)
        {
            isSeekingMedia = true;
        }
    
    //and this code is to update the video position based on the slider value.
    private void videoSlider_DragCompleted(object sender, RoutedEventArgs e)
        {
            if (videoPlayer.Source != null)
            {
                isSeekingMedia = false;
                this.videoPlayer = player.SeekVideo(videoPlayer, videoSlider.Value);
            }
        }
