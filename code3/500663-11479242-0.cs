    public class MyClass
    {
        Button myButton;
        MyClass()
        {
            ...
            myButton.addMouseListener(new ButtonHandler());
        }
        public class ButtonHandler implements MouseListener
        {
            public void mousePressed(MouseEvent e) {}
            public void mouseReleased(MouseEvent e) {}
            public void mouseEntered(MouseEvent e) {}
            public void mouseExited(MouseEvent e) {}
    
            public void mouseClicked(MouseEvent e)
            {
               doSomething("Mouse clicked", e);
            }
        }
    }
