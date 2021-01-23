    for (var i = 1; i < gridLength - 1; i++) {
    
    
                        sprice = grid.rows[i].cells[3].innerText;
    
                        sprice = sprice.replace(code, "");
    
                        sprice = sprice.replace(",", "");
                        if (sprice == "")
                            price = 0;
                        else
                            price = parseFloat(sprice);
    
                      
                        subTotal = subTotal + parseFloat(price);
              
                    }
