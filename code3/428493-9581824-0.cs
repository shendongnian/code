    TimeSpan span = dataGridView1[3,0].Value.Subtract ( dataGridView1[5,0].Value );
    Console.WriteLine( "Time Difference (seconds): " + span.Seconds );
    Console.WriteLine( "Time Difference (minutes): " + span.Minutes );
    Console.WriteLine( "Time Difference (hours): " + span.Hours );
    Console.WriteLine( "Time Difference (days): " + span.Days );
