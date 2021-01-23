    Imports OpenQA.Selenium'
    Module SearchResults
    Sub Main()
        Try
            Dim Browser As Chrome.ChromeDriver = New Chrome.ChromeDriver("C:\SeleniumLive\DriverFiles\")
            Browser.Navigate.GoToUrl("https://www.google.co.in")
            For i = 0 To 4
                If Browser.FindElement(By.Id("lst-ib")) Is Nothing Then
                    Threading.Thread.Sleep(1000)
                End If
            Next
            If Browser.FindElement(By.Id("lst-ib")) IsNot Nothing Then
                Browser.FindElement(By.Id("lst-ib")).SendKeys("Sumit Shitole" & Keys.Enter)
            End If
            Threading.Thread.Sleep(3000)
            For pageNumber As Integer = 1 To 8 Step 1
                Console.WriteLine("......Result from page " & pageNumber & "..........")
                Dim results As New List(Of IWebElement)(Browser.FindElements(By.CssSelector(".r>a")))
                For Each result As IWebElement In results
                    Console.WriteLine(result.Text)
                Next
                Browser.FindElement(By.Id("pnnext")).Click()
                Threading.Thread.Sleep(3000)
            Next
            Console.ReadLine()
            Browser.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
        Console.ReadKey()
    End Sub
    End Module
            
