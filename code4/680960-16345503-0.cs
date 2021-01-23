    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO.Ports;
    using System.Windows.Threading;
    using System.Collections.Concurrent;
    void someRoutine()
    {
        // initialize queue before using it
        serialDataQueue = new ConcurrentQueue<char>();
    }
    /// <summary>
    /// data from serialPort is added to the queue as individual chars, 
    /// a struct may be better
    /// </summary>
    public ConcurrentQueue<char> serialDataQueue;
    // get data
    void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = sender as SerialPort;
        int bytesAvailable = sp.BytesToRead;
        
        // array to store the available data    
        char[] recBuf = new char[bytesAvailable];
        
        try
        {    
            // get the data
            sp.Read(recBuf, 0, bytesAvailable);
            // put data, char by char into a threadsafe FIFO queue
            // a better aproach maybe is putting the data in a struct and enque the struct        
            for (int index = 0; index < bytesAvailable; index++)
               serialDataQueue.Enqueue(recBuf[index]);
            
        }
        catch (TimeoutException ex)
        {
            // handle exeption here
        }
    }
        
    /// <summary>
    /// Check queue that contains serial data, call this 
    /// routine at intervals using a timer or button click
    /// or raise an event when data is received
    /// </summary>
    private void readSearialDataQueue()
    {
        char ch;
        try
        {
            while (serialDataQueue.TryDequeue(out ch))
            {
                // do something with ch, add it to a textbox 
                // for example to see that it actually works
                textboxDataReceived.Text += ch;
            }
        }
        catch (Exception ex)
        {
            // handle ex here
        }
    }
            
            
            
