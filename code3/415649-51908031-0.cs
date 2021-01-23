    using System.Threading;
    static Timer timer;
    
    void Main()
    {	
        // 1000 - DateTime.UtcNow.Millisecond = number of milliseconds until the next second
    	timer = new Timer(TimerCallback, null, 1000 - DateTime.UtcNow.Millisecond, 0);
    }
    
    void TimerCallback(object state)
    {   
        // Important to do this before you do anything else in the callback
    	timer.Change(1000 - DateTime.UtcNow.Millisecond, 0);
    	Debug.WriteLine(DateTime.UtcNow.ToString("ss.ffff"));
    }
    
    Sample Output:
    ...
    25.0135
    26.0111
    27.0134
    28.0131
    29.0117
    30.0135
    31.0127
    32.0104
    33.0158
    34.0113
    35.0129
    36.0117
    37.0127
    38.0101
    39.0125
    40.0108
    41.0156
    42.0110
    43.0141
    44.0100
    45.0149
    46.0110
    47.0127
    48.0109
    49.0156
    50.0096
    51.0166
    52.0009
    53.0111
    54.0126
    55.0116
    56.0128
    57.0110
    58.0129
    59.0120
    00.0106
    01.0149
    02.0107
    03.0136
