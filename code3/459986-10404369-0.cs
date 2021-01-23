    string errmsg = string.empty;
    try { 
        DoSomething();
    }
    catch (FooException) {
       errmsg = "There was a Foo error";
    }
    catch (WidgetException) {
       errmsg = "There was a problem with a Widget";
    }
    catch (Exception ex) {
       errmsg = "General problem: " + ex.Message;
    }
    if (!string.IsNullOrEmpty(errmsg))
       MessageBox.Show(errmsg);
