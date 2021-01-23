    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    
    [assembly: InternalsVisibleTo("System.Runtime.Serialization")]
    
    namespace SL_ButtonAndText
    {
        public partial class MainPage : UserControl
        {
            public MainPage()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                AddToDebug(typeof(DataContractSerializer).Assembly.FullName);
                MemoryStream ms = new MemoryStream();
                DataContractSerializer dcs = new DataContractSerializer(typeof(SerializableGameState));
                SerializableGameState sgs = new SerializableGameState
                {
                    connections = new List<List<int>>
                    {
                        new List<int> { 1, 2, 3 },
                        new List<int> { 4, 5 },
                    },
                    playerPosition = 0
                };
                try
                {
                    dcs.WriteObject(ms, sgs);
                    AddToDebug("Serialized: {0}", Encoding.UTF8.GetString(ms.GetBuffer(), 0, (int)ms.Position));
                }
                catch (Exception ex)
                {
                    AddToDebug("Exception: {0}", ex);
                }
            }
    
            private void AddToDebug(string text, params object[] args)
            {
                if (args != null && args.Length > 0) text = string.Format(text, args);
                this.Dispatcher.BeginInvoke(() => this.txtDebug.Text = this.txtDebug.Text + text + Environment.NewLine);
            }
        }
    
        [DataContract]
        internal class SerializableGameState
        {
            [DataMember]
            public List<List<int>> connections;
            [DataMember]
            public int playerPosition;
        }
    }
