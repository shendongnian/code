cs
using System;
using System.Net.Sockets;
// ...
bool IsPortOpen(string host, int port, TimeSpan timeout)
{
    try
    {
        using(var client = new TcpClient())
        {
            var result = client.BeginConnect(host, port, null, null);
            var success = result.AsyncWaitHandle.WaitOne(timeout);
            client.EndConnect(result);
            return success;
        }
    }
    catch
    {
        return false;
    }
}
And, in F#:
fs
open System
open System.Net.Sockets
let isPortOpen (host: string) (port: int) (timeout: TimeSpan): bool =
    try
        use client = new TcpClient()
        let result = client.BeginConnect(host, port, null, null)
        let success = result.AsyncWaitHandle.WaitOne timeout
        client.EndConnect result
        success
    with
    | _ -> false
  
let available = isPortOpen "stackoverflow.com" 80 (TimeSpan.FromSeconds 10.)
printf "Is stackoverflow available? %b" available
