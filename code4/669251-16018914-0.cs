     public void example1()
        {
        ExampleElement.click();
        ExampleElement2 = wait.Until<IWebElement>((d) =>
                    {
                        return d.FindElement(By.Id("ExampleElement ID"));
                    });
        ExampleElement2.click();
        }
