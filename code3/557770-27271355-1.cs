	var task1 = FaFTaskFactory.StartNew( () => { throw new NullReferenceException(); } );
    var task2 = FaFTaskFactory.StartNew( () => { throw new NullReferenceException(); },
                                          c => {    Console.WriteLine("Exception!"); },
                                          c => {    Console.WriteLine("Success!"  ); } );
    task1.Wait(); // You can omit this
    task2.Wait(); // You can omit this
