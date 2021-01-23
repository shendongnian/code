    <#@ ... hostspecific="true"  extension=".js">
    <#
        Write (System.IO.File.ReadAllText("a.js"));
        Write (System.IO.File.ReadAllText("b.js"));
     #>
