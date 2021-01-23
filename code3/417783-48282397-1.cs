    Imports System.Text
    
    'original version by Jonathan Levison (C#)'
    'http://sleepingbits.com/2010/01/command-line-arguments-with-double-quotes-in-net/
    'converted using http://www.developerfusion.com/tools/convert/csharp-to-vb/
    'and then some manual effort to fix language discrepancies
    Friend Class CommandLineHelper
      ''' <summary>
      ''' C-like argument parser
      ''' </summary>
      ''' <param name="commandLine">Command line string with arguments. Use Environment.CommandLine</param>
      ''' <returns>The args[] array (argv)</returns>
      Public Shared Function CreateArgs(commandLine As String) As String()
        Dim argsBuilder As New StringBuilder(commandLine)
        Dim inQuote As Boolean = False
    
        ' Convert the spaces to a newline sign so we can split at newline later on
        ' Only convert spaces which are outside the boundries of quoted text
        For i As Integer = 0 To argsBuilder.Length - 1
          If argsBuilder(i).Equals(""""c) Then
            inQuote = Not inQuote
          End If
    
          If argsBuilder(i).Equals(" "c) AndAlso Not inQuote Then
            argsBuilder(i) = ControlChars.Lf
          End If
        Next
    
        ' Split to args array
        Dim args As String() = argsBuilder.ToString().Split(New Char() {ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)
    
        ' Clean the '"' signs from the args as needed.
        For i As Integer = 0 To args.Length - 1
          args(i) = ClearQuotes(args(i))
        Next
    
        Return args
      End Function
    
      ''' <summary>
      ''' Cleans quotes from the arguments.<br/>
      ''' All signle quotes (") will be removed.<br/>
      ''' Every pair of quotes ("") will transform to a single quote.<br/>
      ''' </summary>
      ''' <param name="stringWithQuotes">A string with quotes.</param>
      ''' <returns>The same string if its without quotes, or a clean string if its with quotes.</returns>
      Private Shared Function ClearQuotes(stringWithQuotes As String) As String
        Dim quoteIndex As Integer = stringWithQuotes.IndexOf(""""c)
        If quoteIndex = -1 Then Return stringWithQuotes
    
        ' Linear sb scan is faster than string assignemnt if quote count is 2 or more (=always)
        Dim sb As New StringBuilder(stringWithQuotes)
        Dim i As Integer = quoteIndex
        Do While i < sb.Length
          If sb(i).Equals(""""c) Then
            ' If we are not at the last index and the next one is '"', we need to jump one to preserve one
            If i <> sb.Length - 1 AndAlso sb(i + 1).Equals(""""c) Then
              i += 1
            End If
    
            ' We remove and then set index one backwards.
            ' This is because the remove itself is going to shift everything left by 1.
            sb.Remove(System.Math.Max(System.Threading.Interlocked.Decrement(i), i + 1), 1)
          End If
          i += 1
        Loop
    
        Return sb.ToString()
      End Function
    End Class
