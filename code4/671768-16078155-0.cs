            RadioButton rbt = sender as RadioButton;
            if (btn != null)
                {
                    case "rbtPercentualmedioanual":
                        _operation = new example2();
                        example1.Visible = true;
                        example2.Visible = true;
                        example3.Visible = false;
                        return;
                    case "rbtPercentualmensal":
                        _operation = new example3();
                        example1.Visible = true;
                        example2.Visible = true;
                        example3.Visible = false;
                        return;
                    case "rbtValorfixo":
                        _operation = new example1();
                        example1.Visible = true;
                        example2.Visible = true;
                        example3.Visible = false;
                    default:
                        break;
