    var popup = driver.WindowHandles[1]; // handler for the new tab
    Assert.IsTrue(!string.IsNullOrEmpty(popup)); // tab was opened
    Assert.AreEqual(driver.SwitchTo().Window(popup).Url, "http://blah"); // url is OK  
    driver.SwitchTo().Window(driver.WindowHandles[1]).Close(); // close the tab
    driver.SwitchTo().Window(driver.WindowHandles[0]); // get back to the main window
