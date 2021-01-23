    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Media.SpeechSynthesis;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
    namespace SpeechMark
    {
      /// <summary>
      /// An empty page that can be used on its own or navigated to within a Frame.
      /// </summary>
      public sealed partial class BlankPage1 : Page
      {
        public BlankPage1()
        {
          this.InitializeComponent();
          m_button.Click += m_button_Click;
          m_audioPlayerPool = new MediaElement[5];
          for(int index = 0; index < m_audioPlayerPool.Length; index++)
          {
            var audioPlayer = new MediaElement();
            audioPlayer.AutoPlay = true;
            m_audioPlayerPool[index] = audioPlayer;
            m_grid.Children.Add(audioPlayer);
          }
          m_textToSpeech = new SpeechSynthesizer();
        }
        async void m_button_Click(object sender, RoutedEventArgs e)
        {
          m_button.IsEnabled = false;
          if (m_audioPlayer != null)
          {
            m_audioPlayer.Stop();
          }
          if (m_stream != null)
          {
            m_stream.Dispose();
            m_stream = null;
          }
          GC.Collect();
          m_audioPlayer = m_audioPlayerPool[m_nextAudioPlayerToUse];
          m_nextAudioPlayerToUse = (m_nextAudioPlayerToUse + 1) % m_audioPlayerPool.Length;
          string ssml = "<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en\"><voice gender=\"female\" xml:lang=\"en\"><prosody rate=\"1\">how are you doing</prosody><mark name=\"utteranceComplete\"/></voice></speak>";
          m_stream = await m_textToSpeech.SynthesizeSsmlToStreamAsync(ssml);
          m_audioPlayer.SetSource(m_stream, m_stream.ContentType);
          m_button.IsEnabled = true;
        }
        private MediaElement m_audioPlayer;
        private MediaElement[] m_audioPlayerPool;
        private int m_nextAudioPlayerToUse = 0;
        private SpeechSynthesizer m_textToSpeech;
        public SpeechSynthesisStream m_stream { get; set; }
      }
    }
