    TableCell tc = GridView1.Cells[indexOfCell]; // where GridView1 is the id of your GridView
    foreach ( Control c in tc.Controls ){
        if ( c is YourControlTypeThatYouKnow ){
            YourControlTypeThatYouKnow myControl = (YourControlTypeThatYouKnow)c;
        }
    }
