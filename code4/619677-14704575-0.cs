    public static IObservable<InputEvent> WhileHeld(this IObservable<InputEvent> source, IObservable<InputEvent> held) {
        return source.Window(held.Press(), _ => held.Release()).Switch();
    }
    ...
    
    var x = InputStream.Where(i => i.Key == "X");
    var shift = InputStream.Where(i => i.Key == "Shift");
    var ctrl = InputStream.Where(i => i.Key == "Ctrl");
    // gets all key presses of X while shift and control are held
    var ctrlShiftX = x.WhileHeld(shift).WhileHeld(ctrl);
   
