        using System;
        using System.Runtime.InteropServices;
        using System.Threading;
        
        namespace MicrophoneTest
        {
            class Program
            {
        
                [DllImport("winmm.dll")]
                private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        
                static void Main(string[] args)
                {
                    //create Test alias
                    mciSendString("open new type waveaudio alias Test", null, 0, 0);
        
                    //start
                    mciSendString("record Test", null, 0, 0);
        
                    Thread.Sleep(3000);
        
                    //pause
                    mciSendString("pause Test", null, 0, 0);
        
                    //save
                    mciSendString("save Test " + "test.wav", null, 0, 0);
                    mciSendString("close Test", null, 0, 0);
                    //press any key
                    Console.ReadKey();
                }
            }
        }
